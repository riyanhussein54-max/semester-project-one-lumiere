# python3 tree.py
import os
import re
from datetime import datetime, timezone

OUTPUT_FILE = "directory-tree.txt"
START_DATE = datetime.fromisoformat("2026-10-29T15:01:00+02:00")


def generate_tree(dir_path, prefix=""):
    """Recursively builds the ASCII tree for folders and .cs files."""
    try:
        entries = sorted(os.listdir(dir_path))
    except PermissionError:
        return []

    valid_items = []
    for item in entries:
        full_path = os.path.join(dir_path, item)
        if os.path.isdir(full_path) or item.endswith(".cs"):
            valid_items.append(item)

    lines = []
    total = len(valid_items)

    for i, item in enumerate(valid_items):
        full_path = os.path.join(dir_path, item)
        is_dir = os.path.isdir(full_path)
        is_last = i == (total - 1)

        branch = "└── " if is_last else "├── "
        display_name = f"{item}/" if is_dir else item
        lines.append(f"{prefix}{branch}{display_name}")

        if is_dir:
            next_prefix = f"{prefix}    " if is_last else f"{prefix}│   "
            lines.extend(generate_tree(full_path, next_prefix))

    return lines


def analyze_codebase(root_dir):
    cs_files = []
    for root, _, files in os.walk(root_dir):
        for f in files:
            if f.endswith(".cs"):
                cs_files.append(os.path.join(root, f))

    file_count = len(cs_files)
    total_loc = 0
    largest_script_loc = 0
    largest_script_name = ""
    largest_class_loc = 0
    largest_class_name = ""

    class_pattern = re.compile(r"class\s+(\w+)")

    for file_path in cs_files:
        try:
            with open(file_path, "r", encoding="utf-8", errors="ignore") as f:
                lines = f.readlines()
        except OSError:
            continue

        loc = len(lines)
        total_loc += loc

        if loc > largest_script_loc:
            largest_script_loc = loc
            largest_script_name = os.path.basename(file_path)

        in_class = False
        current_class_lines = 0
        brace_count = 0
        temp_class_name = ""

        for line in lines:
            if not in_class:
                match = class_pattern.search(line)
                if match:
                    in_class = True
                    temp_class_name = match.group(1)
                    current_class_lines = 0
                    brace_count = 0

            if in_class:
                current_class_lines += 1
                brace_count += line.count("{")
                brace_count -= line.count("}")

                if brace_count <= 0 and current_class_lines > 2:
                    in_class = False
                    if current_class_lines > largest_class_loc:
                        largest_class_loc = current_class_lines
                        largest_class_name = temp_class_name

    avg_loc = round(total_loc / file_count) if file_count > 0 else 0

    return {
        "file_count": file_count,
        "total_loc": total_loc,
        "avg_loc": avg_loc,
        "largest_script_name": largest_script_name,
        "largest_script_loc": largest_script_loc,
        "largest_class_name": largest_class_name,
        "largest_class_loc": largest_class_loc,
    }


def main():
    now = datetime.now(timezone.utc)
    age = now - START_DATE
    days = age.days
    hours = age.seconds // 3600

    metrics = analyze_codebase(".")
    tree_lines = generate_tree(".")

    output_content = [
        "Project:",
        "- Title: Lumiére",
        f"- Development Age: {days} days, {hours} hours",
        "",
        "Codebase Size:",
        f"- C# Files: {metrics['file_count']}",
        f"- Lines of Code: {metrics['total_loc']:,}",
    ]

    output_content.extend(["", "src/"])
    output_content.extend(tree_lines)

    with open(OUTPUT_FILE, "w", encoding="utf-8") as f:
        f.write("\n".join(output_content) + "\n")

    print(f"Success! Tree exported to {OUTPUT_FILE}")


if __name__ == "__main__":
    main()

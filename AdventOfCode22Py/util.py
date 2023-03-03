from typing import List


def get_data_lines(day: int) -> List[str]:
    with open(f"data/Day{day}.txt", "rt") as f:
        return [line.replace("\n", "") for line in f]

def is_none_or_empty(s: str) -> bool:
    return s is None or s == ""

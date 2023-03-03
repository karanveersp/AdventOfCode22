import util

def get_sole_element(s: set[str]) -> str:
    return list(s)[0]

def misplaced_items_sum():
    letters = "ABCDEFGHIJKLMNOPQRSTUVWXYZ"
    priorities = "_" + letters.lower() + letters  # index is priority
    lines = [line.replace("\n", "") for line in util.get_data_lines(3)]

    pairs = [(s[:len(s)//2], s[len(s)//2:]) for s in lines]
    intersecting_chars = [set(fst) & set(snd) for fst, snd in pairs]
    priority_sum = sum([priorities.index(get_sole_element(c)) for c in intersecting_chars])
    print(priority_sum)

def group_badges_sum():
    letters = "ABCDEFGHIJKLMNOPQRSTUVWXYZ"
    priorities = "_" + letters.lower() + letters  # index is priority
    lines = [line.replace("\n", "") for line in util.get_data_lines(3)]

    all_groups = []
    trio = []
    for i, line in enumerate(lines): 
        if i > 0 and i % 3 == 0:
            all_groups.append(trio)
            trio = [line]
        else:
            trio.append(line)
    all_groups.append(trio)

    def badge_priority(group) -> int:
        fst, snd, thd = group 
        badge = set(fst) & set(snd) & set(thd)
        return priorities.index(get_sole_element(badge))
    
    sum_of_badges = sum([badge_priority(grp) for grp in all_groups])
    print(sum_of_badges)

misplaced_items_sum()
group_badges_sum()


    
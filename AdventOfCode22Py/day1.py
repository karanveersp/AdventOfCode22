from typing import List
import util
import functools as ft

class ElfCarrier:
    def __init__(self, count) -> None:
        self.count = count 

def parse_carriers() -> List[ElfCarrier]:
    lines = util.get_data_lines(1)
    count = 0
    carriers = []
    for line in lines:
        if util.is_none_or_empty(line):
            carriers.append(ElfCarrier(count))
            count = 0
        else:
            count += int(line)
    carriers.append(ElfCarrier(count))
    return carriers

def max_elf_carrier():
    carriers = parse_carriers()
    max_amt = ft.reduce(lambda m, c: max(m, c.count), carriers, 0)
    print(max_amt)

def sum_top_three_carriers():
    carriers = parse_carriers()
    top_three = sorted(carriers, key=lambda c: c.count)[-3:]
    sum_top_three = sum([c.count for c in top_three])
    print(sum_top_three)


max_elf_carrier()
sum_top_three_carriers()
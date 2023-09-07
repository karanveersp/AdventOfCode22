package main

import (
	"bufio"
	"fmt"
	"os"
	"strconv"
)

type elfCarrier struct {
	ID       int
	Calories int
}

func parseCarriers(file string) ([]elfCarrier, error) {
	f, err := os.Open(file)
	if err != nil {
		return nil, err
	}

	scanner := bufio.NewScanner(f)

	var carriers []elfCarrier
	var count, id int
	for scanner.Scan() {
		line := string(scanner.Bytes())
		if line == "" {
			elf := elfCarrier{id, count}
			carriers = append(carriers, elf)
			count = 0
			id++
		} else {
			calories, err := strconv.Atoi(line)
			if err != nil {
				return nil, err
			}
			count += calories
		}
	}
	carriers = append(carriers, elfCarrier{id, count})
	return carriers, nil
}

func printMaxCarrierCalories() {
	carriers, err := parseCarriers("Day1.txt")
	if err != nil {
		panic(err)
	}
	maxCalories := 0
	for _, elf := range carriers {
		if elf.Calories > maxCalories {
			maxCalories = elf.Calories
		}
	}
	fmt.Println(maxCalories)
}

func main() {
	printMaxCarrierCalories()
}

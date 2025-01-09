import java.util.ArrayList;
import java.util.Arrays;
import java.util.List;
import java.util.Scanner;
import java.util.stream.Collectors;

public class Main {
    public static void main(String[] args) {
        System.out.println("Pass input");

        Scanner scanner = new Scanner(System.in);
        List<String> lines = new ArrayList<>();
        List<Result> results = new ArrayList<>();
        String line;
        while (!(line = scanner.nextLine()).isEmpty()) {
            lines.add(line);
        }
        createMatrix(lines, results);
        long total = 0;
        for (Result result : results) {
            total += CalculateTotal(result);
        }

        System.out.println("Total: " + total);
    }

    static void createMatrix(List<String> lines, List<Result> results) {
        for (String line : lines) {
            long FinalResult = Long.parseLong(line.substring(0, line.indexOf(":")));
            long[] numbers = parseNumbers(line.substring(line.indexOf(": ") + 1));
            Result result = new Result(FinalResult, numbers);
            results.add(result);
        }
    }

    static long[] parseNumbers(String numbersStr) {
        return Arrays.stream(numbersStr.split(" "))
                .filter(x -> {
                    try {
                        Long.parseLong(x);
                        return true;
                    } catch (NumberFormatException e) {
                        return false;
                    }
                })
                .mapToLong(Long::parseLong)
                .toArray();
    }

    static List<String> GeneratePossibilities(long[] array) {
        char[] possible = new char[] { '*', '+' };
        List<String> results = new ArrayList<>();

        if (array.length == 2) {
            for (char op : possible) {
                results.add(Character.toString(op));
            }
        } else if (array.length > 2) {
            GenerateCombinations(array.length - 1, possible, "", results);
        }

        return results;
    }

    static void GenerateCombinations(int length, char[] possible, String current, List<String> results) {
        if (current.length() == length) {
            results.add(current);
            return;
        }

        for (char op : possible) {
            GenerateCombinations(length, possible, current + op, results);
        }
    }

    static long CalculateTotal(Result result) {
        List<String> possibilities = GeneratePossibilities(result.numbers);

        for (String possibility : possibilities) {
            if (ApplyOperators(result.numbers, possibility) == result.FinalResult) {
                return result.FinalResult; // Přičte pouze jednou a vrátí
            }
        }

        return 0; // Pokud žádná kombinace nevyhovuje, vrátí 0
    }

    static long ApplyOperators(long[] numbers, String operators) {
        long result = numbers[0];

        for (int i = 0; i < operators.length(); i++) {
            result = ApplyOperator(result, numbers[i + 1], operators.charAt(i));
        }

        return result;
    }

    static long ApplyOperator(long a, long b, char op) {
        switch (op) {
            case '*':
                return a * b;
            case '+':
                return a + b;
            default:
                throw new IllegalArgumentException("Invalid operator");
        }
    }
}

class Result {
    long FinalResult;
    long[] numbers;

    Result(long finalResult, long[] numbers) {
        this.FinalResult = finalResult;
        this.numbers = numbers;
    }
}
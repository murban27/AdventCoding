import java.util.*;

public class Main {
    private static String[] inputStrings;
    private static long[] inputStones;
    public static Map<Pair, Long> Cache = new HashMap<>();

    public static void main(String[] args) {
        inputStrings = Init();
        inputStones = CreateField();
        long sum = Arrays.stream(inputStones).map(x -> EvalCalc(x, 25)).sum();
        System.out.println(sum);
    }

    public static long EvalCalc(long stone, int blinks) {
        Pair key = new Pair(stone, blinks);
        if (Cache.containsKey(key)) {
            return Cache.get(key);
        }
        long result;
        if (blinks == 0) {
            return 1;
        } else if (stone == 0) {
            result = EvalCalc(1, blinks - 1);
        } else if (Long.toString(stone).length() % 2 == 0) {
            String parseStone = Long.toString(stone);
            long leftnode = Long.parseLong(parseStone.substring(0, parseStone.length() / 2));
            long rightnode = Long.parseLong(parseStone.substring(parseStone.length() / 2));
            result = EvalCalc(leftnode, blinks - 1) + EvalCalc(rightnode, blinks - 1);
        } else {
            result = EvalCalc(stone * 2024, blinks - 1);
        }
        Cache.put(key, result);
        return result;
    }

    public static long[] CreateField() {
        return Arrays.stream(inputStrings).mapToLong(Long::parseLong).toArray();
    }

    public static String[] Init() {
        System.out.println("Init stone");
        Scanner scanner = new Scanner(System.in);
        String line = scanner.nextLine();
        return line.split(" ");
    }

    static class Pair {
        long stone;
        int blinks;

        Pair(long stone, int blinks) {
            this.stone = stone;
            this.blinks = blinks;
        }

        @Override
        public boolean equals(Object o) {
            if (this == o) return true;
            if (o == null || getClass() != o.getClass()) return false;
            Pair pair = (Pair) o;
            return stone == pair.stone && blinks == pair.blinks;
        }

        @Override
        public int hashCode() {
            return Objects.hash(stone, blinks);
        }
    }
}

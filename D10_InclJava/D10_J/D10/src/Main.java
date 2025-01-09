import java.awt.Point;
import java.util.ArrayList;
import java.util.List;
import java.util.Scanner;

public class Main {
    static int[][] arrayIntegers;
    static List<Point> points = new ArrayList<>();
    static int counter = 0;

    public static void main(String[] args) {
        points.add(new Point(0, 1));
        points.add(new Point(0, -1));
        points.add(new Point(-1, 0));
        points.add(new Point(1, 0));

        System.out.println("Hello, World!");
        System.out.println("pass inputs");

        Scanner scanner = new Scanner(System.in);
        List<String> lines = new ArrayList<>() ;
        String line;

        while (!(line = scanner.nextLine()).isEmpty()) {
            lines.add(line);
        }

        arrayIntegers = makeIntArrayFromList(lines);

        for (int i = 0; i < arrayIntegers.length; i++) {
            for (int j = 0; j < arrayIntegers[i].length; j++) {
                if (arrayIntegers[i][j] == 0) {
                    boolean[][] visited = new boolean[arrayIntegers.length][arrayIntegers[0].length];
                    walk(i, j, visited);
                }
            }
        }

        System.out.println("The result is "+counter);
    }

    static void walk(int x, int y, boolean[][] visited) {
        if (visited[x][y]) return;
        visited[x][y] = true;

        int value = arrayIntegers[x][y];
        if (value == 9) {
            counter++;
        } else {
            for (Point point : points) {
                int newX = x + point.x;
                int newY = y + point.y;
                if (newX >= 0 && newX < arrayIntegers.length && newY >= 0 && newY < arrayIntegers[0].length && !visited[newX][newY] && arrayIntegers[newX][newY] == value + 1) {
                    walk(newX, newY, visited);
                }
            }
        }
    }

    static int[][] makeIntArrayFromList(List<String> lines) {
        int[][] array = new int[lines.size()][lines.get(0).length()];
        for (int i = 0; i < lines.size(); i++) {
            for (int j = 0; j < lines.get(i).length(); j++) {
                array[i][j] = Character.getNumericValue(lines.get(i).charAt(j));
            }
        }
        return array;
    }
}
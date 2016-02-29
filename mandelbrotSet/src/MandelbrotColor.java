import java.awt.Color;
import java.io.File;
import java.awt.image.BufferedImage;
import javax.imageio.ImageIO;

public class MandelbrotColor {
    public static void main(String[] args) throws Exception {
        int width = 1890;
        int height = 1417;
        int iterNum = 2000;
        BufferedImage image = new BufferedImage(width, height, BufferedImage.TYPE_INT_RGB);
        int empty = 0;
        int[] colors = new int[iterNum];
        for (int j = 0; j<iterNum; j++) {
            colors[j] = Color.HSBtoRGB(j/25f, 1, j/(j+10f));
        }
        for (int row = 0; row < height; row++) {
            for (int column = 0; column < width; column++) {
                double real = (column - width/2)*4.0/width;
                double imaginary = (row - height/2)*4.0/width;	
                double x = 0, y = 0;
                int iteration = 0;
                while (x * x + y * y < 4 && iteration < iterNum) {
                    double newX = x * x - y * y + real;
                    y = 2 * x * y + imaginary;
                    x = newX;
                    iteration++;
                } 
                if (iteration < iterNum) image.setRGB(column, row, colors[iteration]);
                else image.setRGB(column, row, empty);
            }
        }

        ImageIO.write(image, "jpg", new File("mandelbrotSet.jpg"));
    }
}
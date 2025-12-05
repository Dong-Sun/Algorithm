namespace CSharp
{
    class Program
    {
        static void Main(string[] args)
        {
            int r, c, t;
            int[] input = Array.ConvertAll(Console.ReadLine().Split(), int.Parse);
            r = input[0];
            c = input[1];
            t = input[2];

            int[,] A = new int[r + 1, c + 1];
            int[,] B = new int[r + 1, c + 1];
            for (int i = 0; i < r; i++)
            {
                input = Array.ConvertAll(Console.ReadLine().Split(), int.Parse);
                for (int j = 0; j < c; j++)
                    A[i + 1, j + 1] = input[j];
            }

            int top = 0;
            int bottom = 0;
            for (int i = 1; i <= r; i++)
            {
                if (A[i, 1] == -1)
                {
                    top = i;
                    bottom = i + 1;
                    break;
                }
            }

            while (t > 0)
            {
                // 미세먼지 확산
                for (int i = 1; i <= r; i++)
                {
                    for (int j = 1; j <= c; j++)
                    {
                        if (A[i, j] > 0)
                        {
                            if (i > 1 && A[i - 1, j] != -1)
                            {
                                B[i, j] = B[i, j] - A[i, j] / 5;
                                B[i - 1, j] = B[i - 1, j] + A[i, j] / 5;
                            }
                            if (i < r && A[i + 1, j] != -1)
                            {
                                B[i, j] = B[i, j] - A[i, j] / 5;
                                B[i + 1, j] = B[i + 1, j] + A[i, j] / 5;
                            }
                            if (j > 1 && A[i, j - 1] != -1)
                            {
                                B[i, j] = B[i, j] - A[i, j] / 5;
                                B[i, j - 1] = B[i, j - 1] + A[i, j] / 5;
                            }
                            if (j < c && A[i, j + 1] != -1)
                            {
                                B[i, j] = B[i, j] - A[i, j] / 5;
                                B[i, j + 1] = B[i, j + 1] + A[i, j] / 5;
                            }
                        }
                    }
                }
                for (int i = 1; i <= r; i++)
                {
                    for (int j = 1; j <= c; j++)
                    {
                        A[i, j] = A[i, j] + B[i, j];
                        B[i, j] = 0;
                    }
                }

                // 공기청정기
                int ypos = top;
                int save = 0;
                int temp;

                // 반시계 방향
                for (int i = 2; i <= c; i++)    // 오른쪽으로
                {
                    temp = A[top, i];
                    A[top, i] = save;
                    save = temp;
                }
                for (int i = top - 1; i >= 1; i--)    // 위쪽으로
                {
                    temp = A[i, c];
                    A[i, c] = save;
                    save = temp;
                }
                for (int i = c - 1; i >= 1; i--)    // 왼쪽으로
                {
                    temp = A[1, i];
                    A[1, i] = save;
                    save = temp;
                }
                for (int i = 2; i < top; i++)    // 아래쪽으로
                {
                    temp = A[i, 1];
                    A[i, 1] = save;
                    save = temp;
                }

                save = 0;
                // 시계 방향
                for (int i = 2; i <= c; i++)    // 오른쪽으로
                {
                    temp = A[bottom, i];
                    A[bottom, i] = save;
                    save = temp;
                }
                for (int i = bottom + 1; i <= r; i++)    // 아래쪽으로
                {
                    temp = A[i, c];
                    A[i, c] = save;
                    save = temp;
                }
                for (int i = c - 1; i >= 1; i--)    // 왼쪽으로
                {
                    temp = A[r, i];
                    A[r, i] = save;
                    save = temp;
                }
                for (int i = r - 1; i > bottom; i--)    // 위쪽으로
                {
                    temp = A[i, 1];
                    A[i, 1] = save;
                    save = temp;
                }
                t--;
            }
            int result = 0;
            for (int i = 1; i <= r; i++)
            {
                for (int j = 1; j <= c; j++)
                    if (A[i, j] != -1)
                        result = result + A[i, j];
            }
            Console.WriteLine(result);
        }
    }
}
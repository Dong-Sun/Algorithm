public class Solution
{
    public int[] solution(string[] id_list, string[] report, int k)
    {
        int[] answer = new int[id_list.Length];

        // 신고받은 횟수를 저장하는 배열
        int[] count = new int[id_list.Length];

        // 이전에 이미 동일한 내용의 신고를 한 경우를 제외하기 위한 2차원 배열
        // 2차원 인덱스 : from   1차원 인덱스 : to   check[from, to] 
        int[,] check = new int[id_list.Length, id_list.Length];
        int from = 0;
        int to = 0;

        //신고받은 내용들 순회
        foreach (string s in report)
        {
            // 문자열 나누기
            // split[0] = 신고한 사람    split[1] = 신고받은 사람
            string[] split = s.Split();

            // id_list에서 이름이 일치한 사람들 탐색
            for (int i = 0; i < id_list.Length; i++)
            {
                // 신고한 사람 탐색
                if (id_list[i] == split[0])
                    from = i;

                // 신고받은 사람 탐색
                if (id_list[i] == split[1])
                    to = i;

            }
            // 중복된 신고가 없을 경우
            if (check[from, to] == 0)
            {
                // 신고됨을 알리고 신고받은 사람의 누적 신고 횟수를 증가
                check[from, to] = 1;
                count[to]++;
            }
        }

        // 도출해낸 값을 answer에 옮기는 과정
        // j = from     i = to
        for (int i = 0; i < count.Length; i++)
        {
            // k번 이상 신고당한 사람 해당
            if (count[i] >= k)
            {
                for (int j = 0; j < check.GetLength(0); j++)
                {
                    answer[j] += check[j, i];
                }
            }
        }

        return answer;
    }
}
bool BinarySearch(int* arr, int size, int value)
{
    //초기 범위
    int start = 0;
    int end = size;

    while(start < end)
    {
        // 시작과 끝의 중간점 지정
        int index = (start + end) / 2;

        if(arr[index] == value)
        {
            // 고른 곳이 원하는 데이터라면 true
            return true;
        }
        else if(arr[index] < value)
        {
            // 고른 곳이 원하는 데이터보다 작다면 시작 위치 조정
            start = index + 1;
        }
        else
        {
            // 고른 곳이 원하는 데이터보다 크다면 종료 위치 조정
            end = index;
        }
    }
}
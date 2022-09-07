#include <iostream>
#include <vector>
using namespace std;

// [][][][][][][][][][]
// 1             : Root Node
// Index * 2     : Left
// Index * 2 + 1 : Right

class Heap
{
public:
    Heap() = default;
    ~Heap() = default;

    // 힙의 가장 큰 원소 반환
    const int& top() const
    {
        return _container.front();
    }

    // 힙이 비었는지 체크
    bool empty() const
    {
        return _container.empty();
    }

    // 힙의 크기 반환
    size_t size() const
    {
        return _container.size();
    }

    // 힙에 값 삽입
    void push(int value)
    {
        // 1. 맨 끝에 데이터 삽입
        _container.push_back(value);

        // 2. 힙의 불변성을 만족할 때까지 데이터를 부모와 바꿔준다.
        // HACK : 첫 번째 노드를 1로 생각
        size_t currentIndex = size();
        while (currentIndex > 1)
        {
            // 2.1. 부모 노드를 찾는다.
            size_t parentIndex = currentIndex / 2;

            // 2.2. 부모 노드와 비교
            if (_container[parentIndex] >= _container[currentIndex - 1])
            {
                // 2.2.1. 부모가 나보다 더 크면 힙의 불변성을 만족.
                break;
            }
            // 2.3. 힙의 불변성을 만족하지 않는다면 부모와 데이터 바꿈
            swap(_container[parentIndex - 1], _container[currentIndex - 1]);
            currentIndex = parentIndex;
        }
    }

    // 힙에서 값을 제거
    void pop()
    {
        // 1. 마지막 노드를 루트 노드로 가져온다.
        _container[0] = _container.back();

        // 2. 마지막 노드를 제거한다.
        _container.pop_back();

        // 3. 힙의 불변성을 만족할때까지 자식이랑 바꾼다.
        const size_t currentSize = _container.size();
        size_t currentIndex = 1;
        while (true)
        {
            size_t left = currentIndex * 2;
            size_t right = left + 1;

            // 3.1. 자식이 존재해야 한다.
            if (left > currentSize)
            {
                break;
            }

            // 3.2. 왼쪽 자식과 오른쪽 자식 중 더 큰 쪽으로 바꾼다.
            size_t child = left;
            if (right <= currentSize && _container[left - 1] < _container[right - 1])
            {
                child = right;
            }

            // 3.3. 바꿀 자식이 없다면 종료한다.
            if (_container[currentIndex - 1] >= _container[child - 1])
            {
                break;
            }

            swap(_container[currentIndex - 1], _container[child - 1]);
            currentIndex = child;
        }
    }

private:
    vector<int> _container;
};
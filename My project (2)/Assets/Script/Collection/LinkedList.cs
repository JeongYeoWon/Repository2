using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Threading;
using UnityEngine;

public class LinkedList<T>
{
    /*public class Node<T> // 제네릭을 사용해 노드 생성
    {
        public T data; // 임의의 데이터 타입을 저장하기 위한 변수
        public Node<T> next; // 다음 노드를 가리킬 변수

        public Node(T data) // 노드 초기화
        {
            this.data = data;
            this.next = null;
        }
        public class Queue<U> // 제네릭을 사용해 큐 생성
        {
            private Node<U> frontNode; // 큐 시작점을 가리키는 변수
            private Node<U> rearNode; // 큐 끝지점을 가리키는 변수
            private int count; // 큐 갯수
            public Queue() // 큐 초기화
            {
                frontNode = rearNode = null; // 큐 시작점과 뒷자리를 한꺼번에 초기화가 되는구나 우와.
            }
            public void Enqueue(U data) // 큐에 추가
            {
                Node<U> newNode = new Node<U>(data); // 새로운 데이터가진 노드를 저장하고 다음 노드를 설정(null)
                if (rearNode == null) // 끝지점에 아무것도 없을 경우(큐가 비어있는 경우)
                {
                    frontNode = rearNode = newNode; // 시작점과끝지점에 새로운 노드를 추가함
                }
                else // 아닐 경우(큐가 비어있지 않는 경우)
                {
                    rearNode.next = newNode; // 끝지점에 새로운 노드를 추가함
                    rearNode = newNode; // 끝지점을 새롭게 추가된 노드로 저장..?변경...?덮어쓰기,,.? 선언?
                }
                Debug.Log("내가 만든 스크립트를 제대로 불러오고 있는지 확인");
                count++;
            }
            public U Dequeue() // 제네릭을 사용해 큐 데이터 삭제
            {
                if (frontNode == null) // 만약 시작점에 아무것도 없다면
                {
                    Debug.Log("큐가 비었음"); // 큐가 비었다고 알림
                    rearNode = null;
                    return default(U); // 기본값 반환
                }
                U data = frontNode.data; // 시작점의 데이터를 저장
                frontNode = frontNode.next; // 시작점을 다음 노드로 변경
                if (frontNode == null) // 큐에 데이터가 없는 경우
                {
                    rearNode = null; // 끝지점도 초기화
                }
                count--;
                return data;
            }

            public int Count()
            {
                return count;
            }
            public bool helpme(int value)
            {
                return count < value;
            }
        }
    }*/

    private Queue<T> queue1 = new Queue<T>();
    private Queue<T> queue2 = new Queue<T>();

    public void Push(T element)
    {
        // 큐1에 요소 추가
        queue1.Enqueue(element);
    }

    public T Pop()
    {
        if (queue1.Count == 0)
        {
            return default(T); // 스택이 비어있을 경우 처리
        }

        // 큐1의 모든 요소를 큐2로 옮기고 마지막 요소를 제외한 나머지 요소는 다시 큐1로 옮김
        while (queue1.Count > 1)
        {
            queue2.Enqueue(queue1.Dequeue());
        }

        // 마지막 요소를 반환
        T poppedElement = queue1.Dequeue();

        // 큐1과 큐2 교체하여 큐2 비움
        SwapQueues();

        return poppedElement;
    }

    public T Top()
    {
        if (queue1.Count == 0)
        {
            return default(T); // 스택이 비어있을 경우 처리
        }

        // 큐1의 모든 요소를 큐2로 옮기고 마지막 요소를 변수에 저장
        while (queue1.Count > 1)
        {
            queue2.Enqueue(queue1.Dequeue());
        }
        T topElement = queue1.Peek();

        // 큐1에 다시 요소를 넣고 큐2를 비움
        SwapQueues();

        return topElement;
    }

    private void SwapQueues()
    {
        Queue<T> temp = queue1;
        queue1 = queue2;
        queue2 = temp;
    }
}
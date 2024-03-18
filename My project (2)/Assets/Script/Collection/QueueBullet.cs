using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class QueueBullet
{
    public class Node<T> // 제네릭을 사용해 노드 생성
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
            public void Dequeue() // 제네릭을 사용해 큐 데이터 삭제
            {
                if (frontNode == null) // 만약 시작점에 아무것도 없다면
                {
                    Debug.Log("큐가 비었음"); // 큐가 비었다고 알림
                    rearNode = null;
                    return;
                }
                Node<U> temp = frontNode; // temp라는 임시 변수에 시작점을 저장해둠
                frontNode = frontNode.next; // 시작점에 있는 데이터를 다음 노드로 이동시킴(오래된 데이터부터 빠져나감)
                count--;
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
    }
}
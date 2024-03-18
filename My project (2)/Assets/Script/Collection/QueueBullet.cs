using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class QueueBullet
{
    public class Node<T> // ���׸��� ����� ��� ����
    {
        public T data; // ������ ������ Ÿ���� �����ϱ� ���� ����
        public Node<T> next; // ���� ��带 ����ų ����

        public Node(T data) // ��� �ʱ�ȭ
        {
            this.data = data;
            this.next = null;
        }
        public class Queue<U> // ���׸��� ����� ť ����
        {
            private Node<U> frontNode; // ť �������� ����Ű�� ����
            private Node<U> rearNode; // ť �������� ����Ű�� ����
            private int count; // ť ����
            public Queue() // ť �ʱ�ȭ
            {
                frontNode = rearNode = null; // ť �������� ���ڸ��� �Ѳ����� �ʱ�ȭ�� �Ǵ±��� ���.
            }
            public void Enqueue(U data) // ť�� �߰�
            {
                Node<U> newNode = new Node<U>(data); // ���ο� �����Ͱ��� ��带 �����ϰ� ���� ��带 ����(null)
                if (rearNode == null) // �������� �ƹ��͵� ���� ���(ť�� ����ִ� ���)
                {
                    frontNode = rearNode = newNode; // ���������������� ���ο� ��带 �߰���
                }
                else // �ƴ� ���(ť�� ������� �ʴ� ���)
                {
                    rearNode.next = newNode; // �������� ���ο� ��带 �߰���
                    rearNode = newNode; // �������� ���Ӱ� �߰��� ���� ����..?����...?�����,,.? ����?
                }
                Debug.Log("���� ���� ��ũ��Ʈ�� ����� �ҷ����� �ִ��� Ȯ��");
                count++;
            }
            public void Dequeue() // ���׸��� ����� ť ������ ����
            {
                if (frontNode == null) // ���� �������� �ƹ��͵� ���ٸ�
                {
                    Debug.Log("ť�� �����"); // ť�� ����ٰ� �˸�
                    rearNode = null;
                    return;
                }
                Node<U> temp = frontNode; // temp��� �ӽ� ������ �������� �����ص�
                frontNode = frontNode.next; // �������� �ִ� �����͸� ���� ���� �̵���Ŵ(������ �����ͺ��� ��������)
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
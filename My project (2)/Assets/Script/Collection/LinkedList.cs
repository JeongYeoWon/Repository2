using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Threading;
using UnityEngine;

public class LinkedList<T>
{
    /*public class Node<T> // ���׸��� ����� ��� ����
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
            public U Dequeue() // ���׸��� ����� ť ������ ����
            {
                if (frontNode == null) // ���� �������� �ƹ��͵� ���ٸ�
                {
                    Debug.Log("ť�� �����"); // ť�� ����ٰ� �˸�
                    rearNode = null;
                    return default(U); // �⺻�� ��ȯ
                }
                U data = frontNode.data; // �������� �����͸� ����
                frontNode = frontNode.next; // �������� ���� ���� ����
                if (frontNode == null) // ť�� �����Ͱ� ���� ���
                {
                    rearNode = null; // �������� �ʱ�ȭ
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
        // ť1�� ��� �߰�
        queue1.Enqueue(element);
    }

    public T Pop()
    {
        if (queue1.Count == 0)
        {
            return default(T); // ������ ������� ��� ó��
        }

        // ť1�� ��� ��Ҹ� ť2�� �ű�� ������ ��Ҹ� ������ ������ ��Ҵ� �ٽ� ť1�� �ű�
        while (queue1.Count > 1)
        {
            queue2.Enqueue(queue1.Dequeue());
        }

        // ������ ��Ҹ� ��ȯ
        T poppedElement = queue1.Dequeue();

        // ť1�� ť2 ��ü�Ͽ� ť2 ���
        SwapQueues();

        return poppedElement;
    }

    public T Top()
    {
        if (queue1.Count == 0)
        {
            return default(T); // ������ ������� ��� ó��
        }

        // ť1�� ��� ��Ҹ� ť2�� �ű�� ������ ��Ҹ� ������ ����
        while (queue1.Count > 1)
        {
            queue2.Enqueue(queue1.Dequeue());
        }
        T topElement = queue1.Peek();

        // ť1�� �ٽ� ��Ҹ� �ְ� ť2�� ���
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
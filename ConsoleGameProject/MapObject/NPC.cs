﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// 맵 상에 N으로 표시되는 NPC 오브젝트 클래스입니다.
public class NPC : MapObject, IInteractable
{
    private Stack<ChatSegment> chat;
    private ChatSegment seg1;
    private ChatSegment seg2;
    public NPC(int y, int x)
    {
        posX = x;
        posY = y;
        symbol = 'N';
        chat = new Stack<ChatSegment>();
        seg1 = new ChatSegment();
        seg1.AddSentence("첫번째 대사의 첫번째 줄.");
        seg1.AddSentence("첫번째 대사의 두번째 줄");
        seg1.AddChoice("     1. 취소");
        seg1.AddChoice("     2. 다음 대사로");
        seg2 = new ChatSegment();
        seg2.AddSentence("두번째 대사의 첫번째 줄.");
        seg2.AddSentence("두번째 대사의 두번째 줄");
        seg2.AddChoice("     1. 뒤로가기");
        seg2.AddChoice("     2. 마침");

    }

    // NPC와 상호작용(대화) 시 선택지에 따라 반환되는 값을 바탕으로
    // 스택을 조정하여 다음 대화로 이동하거나, 대화를 종료합니다.
    public void Interact()
    {
        chat.Push(seg1);
        while (chat.Count > 0)
        {
            chat.Peek().Clear();
            chat.Peek().Render();
            chat.Peek().Input();
            if (chat.Peek() == seg1 && 
                chat.Peek().ReturnInput() == 1)
            {
                chat.Pop();
            }
            else if (chat.Peek() == seg1 && 
                chat.Peek().ReturnInput() == 2)
            {
                chat.Push(seg2);
            }
            else if (chat.Peek() == seg2 && 
                chat.Peek().ReturnInput() == 1)
            {
                chat.Pop();
            }
            else if (chat.Peek() == seg2 && 
                chat.Peek().ReturnInput() == 2)
            {
                chat.Clear();
            }
        }
    }
}
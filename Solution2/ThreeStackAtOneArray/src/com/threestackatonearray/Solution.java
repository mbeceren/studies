package com.threestackatonearray;

public class Solution {
	
	private int _size;
	private int[] _arrMain;
	private int top1;
	private int top2;
	private int size2;
	private int top3;
	
	private int getHead2() {
		return  top2 - size2 + 1;
	}
	
	public Solution(int size) {
		_size = size;
		_arrMain = new int[_size];
		
		top1 = -1;
		top2 = (int)Math.floor(size/3);
		size2 = 0;
		top3 = size;
	}
	
	public void push1(int elm) {
		boolean canPush = false;
		
		if (top1 + 1 < getHead2() && top1 + 1 < top3)
			canPush = true;
		else if (top1 + 1 < top3) {
			shiftTop2();
			if (top1 + 1 < getHead2())
				canPush = true;
		}
		
		if (canPush) {
			_arrMain[++top1] = elm;
			System.out.println("push1, pushed value: " + elm);
		}
		else
			System.out.println("you cannot push1.(stackoverflow)");
	}
	
	public void pop1() {
		if (top1 == -1) 
			System.out.println("you cannot pop1 because its empty.(stackunderflow)");
		else {
			System.out.println("pop1, popped value is: " + _arrMain[top1]);
			_arrMain[top1--] = 0;
		}
	}
		
	public void push2(int elm) {
		boolean canPush = false;
		if (top2 + 1 < top3) {
			canPush = true;
			
		}
		else{
			shiftTop2();
			
			if (top2 + 1 < top3)
				canPush = true;
		}
		
		if (canPush) {
			_arrMain[++top2] = elm;
			size2++;
			System.out.println("push2, pushed value: " + elm);	
		}
		else
			System.out.println("you cannot push2.(stackoverflow)");
	}
	
	public void pop2() {
		if (top1 < top2 && top2 < top3) {
			System.out.println("pop2, poped value: " + _arrMain[top2]);
			_arrMain[top2--] = 0;
			size2--;
		}
		else
			System.out.print("you cant pop2 because its empty. (stackunderflow)");
	}
	
	public void push3(int elm) {
		boolean canPush = false;
		if (top3 - 1 > top2)
			canPush = true;
		else {
			shiftTop2();
			
			if (top3 - 1 > top2)
				canPush = true;
		}
		
		if (canPush) {
			_arrMain[--top3] = elm;
			System.out.println("push3, pushed value: " + elm);
		}
		else
			System.out.println("you cannot push3.(stackoverflow)");
	}
	
	public void pop3() {
		if (top3 == _size) 
			System.out.print("you cant pop3 because its empty. (stackunderflow)");
		else {
			System.out.println("pop3, poped value: " + _arrMain[top3]);
			_arrMain[top3++] = 0;
		}
	}
	
	
	public void print() {
		String format = "%s: %d %s";
		for (int i=0; i < _size; i++) {	
			String currentStack = "";
			String currentTop = "";
			int currentValue = _arrMain[i];
			
			if (top1 >= i) {
				currentStack = "Stack1";
				if (top1 == i)
					currentTop = " - Top1";
			}
			else if (getHead2() <= i && top2 >= i) {
				currentStack = "Stack2";
				if (top2 == i)
					currentTop = " - Top2";
			}
			else if (i >= top3) {
				currentStack = "Stack3";
				if (top3 == i)
					currentTop = " - Top3";
			}
			else {
				currentStack = "empty";
			}
			
			String text = String.format(format, currentStack, currentValue, currentTop);			
			System.out.println(text);
		}
	}

	private void shiftTop2() {
		int emptySpace1 = Math.abs(top1 - getHead2() +1); 
		int emptySpace2 = Math.abs(top2 - top3 + 1); 
		int totalEmptySpace = emptySpace1 + emptySpace2; 
		if (totalEmptySpace == 0)
			return;
		
		int medianOfEmpty = (int)Math.floor(totalEmptySpace / 2) + totalEmptySpace % 2; 
		int shiftCount = medianOfEmpty; 
		int newHead2 = top1;
		
		if (emptySpace1 > 0) {
			if (emptySpace1 <= shiftCount) {
				newHead2 = top1 + emptySpace1;
				shiftCount -= emptySpace1;
			}
			else {
				newHead2 = top1 + shiftCount;
				shiftCount = 0;
			}
		}
		
		if (shiftCount != 0) {
			newHead2 = getHead2() + shiftCount;
			shiftCount = 0;
		}
		
		int[] temp2 = new int[size2];
		for (int i = 0; i < size2; i++) {
			int oldIndex2 = getHead2() + i; 
			temp2[i] = _arrMain[oldIndex2];
			_arrMain[oldIndex2] = 0;
		}
		
		for (int t = 0; t < temp2.length; t++) {
			int newIndex2 = newHead2 + t;
			_arrMain[newIndex2] = temp2[t];
		}
		
		top2 = newHead2 + size2 - 1;
	}
}

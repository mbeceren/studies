package com.threestackatonearray;

import com.threestackatonearray.Solution;

public class Program {

	public static void main(String[] args) {
		
		Solution solution = new Solution(12);
		
		solution.push1(10);
		solution.push1(10);
		solution.push2(20);
		solution.push3(30);
		solution.push2(20);
		
		solution.push1(10);
		
		solution.pop1();
		solution.push1(10);
		solution.pop1();
		solution.push3(30);
		solution.pop1();
		solution.push2(20);
		solution.pop3();
		solution.pop2();
		solution.push1(10);
		solution.push3(30);
		solution.push3(30);
		solution.pop3();
		solution.print();
	}

}

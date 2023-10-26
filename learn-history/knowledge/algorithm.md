# Algorithms

## Divide And Conquer:
### Explain
divide a big problem into many small problems, then fix every small problems, finally combine the results.
### Examples
1. Binary search in a sorted array;
2. Calculate Fibonacci numbers by calculate matrics (1 1, 1 0) of power(n) (f(n+1) fn, fn, f(n-1));
3. calculate X power(n)
4. Merge Sort:  
	1. sort：
		a. if only 1 element, no need to sort, just return;
		b. if more than one, split into 2 arrays, sort left， sort right, then merge left and right
	2. merge :
		loop:
		a. pick element from first and second array,
		b. insert the smaller one to slice
		c. smaller one related array index +1 (ready to pick next in the smaller one array)
		d. if any array is empty, append another array to result slice
		
5. Quick Sort [arr, start, end]: 
	if start >= end: one element or no element, just return

	a. select a random pivot index, 
	b. swap pivot and start, 
	c. set partitionIndex = start
	d. loop from start+1 to end (included)
		1. if element <= start，swap(arr, element, partitionIndex + 1), partitionIndex +=1
		2. if element >start, do nothing
	e. after loop finished, swap(arr, start, partitionIndex) --- now we found the pivot location in array, left is small or equal, right is bigger than pivot; 
	f. then quick sort left and right sub-array. --- sort(arr, start, partitionIndex -1) &&  sort(arr, partitionIndex + 1， end)
	
6. Find x th min / max element in array: 
	a. take advantage of quick sort - find pivot location, 
	b. if that is x, then we found that, otherwise found in left or right part with quick sort again;
	
## Dynamic Programming

### Define
a problem can be calculated from it sub-problems (from one or many of them): store a result set of its sub-problems, then calculte the results base on these sub-problems, so we dont need to calculate again and again on those sub-problems.

### Examples
1. Fibonacci from 0/1 to n;
2. Cut rod problem: 钢条切割问题；
3. 上台阶问题：n 个台阶，一次只有1-x步走法，有多少种走法。
4. 无界背包问题


## BackTracking

## Hash Algorithms

## Tree

## Greedy Algoritm 
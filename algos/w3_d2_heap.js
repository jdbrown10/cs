//same structure as a BST but smallest value is always at the top
//also-- this doesn't use nodes! they are simply just values. it COULD be build out with nodes with some other tags, but for today, it's just values

//instead of a left and a right, we're going to have a x2 and a x2+1 -> this will get the location of the children
//the underlying structure of a heap is an array! 
//with an array, indexes are built on hard coded values, so we know the first value is located at 0, the second is located at 1, etc etc...

//the value at 0 must always be null because if you were to use the formulas on 0, you would always get 0's on the left

class MinHeap {
    constructor() {
        this.heap = [null];
    }
    size() {
        return this.heap.length - 1;
    }

    top() {
        //can do this in one line with a ternary operator
        return this.size() > 0 ? this.heap[1] : null;
    }

    insert(num) {
        this.heap.push(num);
        this.shiftUp();
        return this.size();
    }

    //this could be part of the insert function, but since it's probably code we'll re-use, it's nice to have it as its own function to keep things clean
    shiftUp() {
        // let's keep track of where our value is
        var idxOfValue = this.heap.length - 1;

        // Good to track if we have encountered idx 0 or are close to it
        while(idxOfValue > 1) {
            // We need to look at the parent
            var parentIdx = Math.floor(idxOfValue/2);
            // And ask "are you larger than me?"
            if(this.heap[idxOfValue] < this.heap[parentIdx]) {
                // If it is, we do a swap
                var temp = this.heap[idxOfValue];
                this.heap[idxOfValue] = this.heap[parentIdx];
                this.heap[parentIdx] = temp;
                // We need to update the idxOfValue now
                idxOfValue = parentIdx;
            } else {
                // If it's not, we break out
                break;
            }
        }
    
    }

    //extract the top value and return it
    //once that's done, the heap needs to be re-ordered
    //remember we're working with an array
    //when we added a value, we shifted everything up the tree
    //start by taking the bottom value and placing it at the top, and then shift everything back down
    //try to figure out which one of its children is smaller-> the smaller value is the one that should come up
    //keep shifting down in that same way. the highest value is gonna land wherever it needs to land (left or right doesn't matter)
    extract() {
        //check if it's null
        if (this.size() < 1) {
            console.log("This heap is empty.")
            return null
        }
        if (this.size() == 1) {
            this.heap.pop()
            return null
        }
        //if it isn't, remove and save the top value
        var topValue = this.heap[1]
        //move the largest value (at the end) to the top
        this.heap[1] = this.heap[this.heap.length - 1]
        this.heap.pop();
        //call shiftDown()
        this.shiftDown();
        //return the top value
        return topValue
    }

    shiftDown() {
        //keep track of where the value is
        var idxOfValue = 1
        //the lowest we can go before reaching the end of the heap is 2, so we should increment up until it gets to index 2 and then stop (keep going as long as it has a parent)
        while (idxOfValue < this.heap.length - 1) {
            //look at child and ask "are you smaller than me?"
            var LeftChildIdx = idxOfValue * 2
            var RightChildIdx = idxOfValue * 2 + 1
            //check which child value is smaller
            if (this.heap[LeftChildIdx] < this.heap[RightChildIdx] || this.heap[RightChildIdx] == null) {
                //then compare it to parent
                if (this.heap[idxOfValue] > this.heap[LeftChildIdx]) {
                    var temp = this.heap[idxOfValue];
                    this.heap[idxOfValue] = this.heap[LeftChildIdx];
                    this.heap[LeftChildIdx] = temp;
                    idxOfValue = LeftChildIdx;
                    //or stop if we don't need to swap
                } else {
                    break
                }
            } else if (this.heap[LeftChildIdx] > this.heap[RightChildIdx] || this.heap[LeftChildIdx] == null) {
                if (this.heap[idxOfValue] > this.heap[RightChildIdx]) {
                    var temp = this.heap[idxOfValue];
                    this.heap[idxOfValue] = this.heap[RightChildIdx];
                    this.heap[RightChildIdx] = temp;
                    idxOfValue = RightChildIdx;
                } else {
                    break
                }
            } else {
                break
            }
        }
    }
}

var myHeap = new MinHeap();

console.log(myHeap.size());

myHeap.insert(8);
console.log(myHeap.heap);
myHeap.insert(3);
console.log(myHeap.heap);
myHeap.insert(9);
console.log(myHeap.heap);
myHeap.insert(1);

console.log(myHeap.heap);

console.log(myHeap.extract());

console.log(myHeap.heap);

console.log(myHeap.extract());

console.log(myHeap.heap);

console.log(myHeap.extract());

console.log(myHeap.heap);

console.log(myHeap.extract());

console.log(myHeap.heap);

console.log(myHeap.extract());

console.log(myHeap.heap);
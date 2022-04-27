//same structure as a BST but smallest value is always at the top
//also-- this doesn't use nodes! they are simply just values. it COULD be build out with nodes with some other tags, but for today, it's just values

//instead of a left and a right, we're going to have a x2 and a x2+1 -> this will get the location of the children
//the underlying structure of a heap is an array! 
//with an array, indexes are built on hard coded values, so we know the first value is located at 0, the second is located at 1, etc etc...

//the value at 0 must always be null because if you were to use the formulas on 0, you would always get 0's on the left

class MinHeap {
    constructor(){
        this.heap = [null];
    }
    size() {
        return this.heap.length - 1;
    }

    top(){
        //can do this in one line with a ternary operator
        return this.size() > 0 ? this.heap[1] : null;
    }

    insert(num){
        this.heap.push(num);
        this.shiftUp();
        return this.size();
    }

    //this could be part of the insert function, but since it's probably code we'll re-use, it's nice to have it as its own function to keep things clean
    shiftUp(){
        //keep track of where the value is
        var idxOfValue = this.heap.length - 1

        //the lowest we can go before reaching the end of the heap is 2, so we should increment up until it gets to index 2 and then stop (keep going as long as it has a parent)
        while (idxOfValue > 1){
            //look at parent and ask "are you larger than me?"
            var parentIdx = Math.floor(idxOfValue/2)

            //if it is, swap them! (using a temp)

            if (this.heap[idxOfValue] < this.heap[parentIdx]) {
                var temp = this.heap[idxOfValue];
                this.heap[idxOfValue] = this.heap[parentIdx];
                this.heap[parentIdx] = temp;

                //increment idxOfValue to go backwards (it's just the parent index now)
                idxOfValue = parentIdx;
            } else {
                //if parent value is not larger, end the loop
                break;
            }
        }
    }
}

var myHeap = new MinHeap();

console.log(myHeap.size());

myHeap.insert(8);
myHeap.insert(3);
myHeap.insert(9);
myHeap.insert(1);

console.log(myHeap.size());

console.log(myHeap.heap);
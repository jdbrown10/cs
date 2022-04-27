//doing the algo in JS first

// Write a function that creates, and then returns, an array that contains all the odd numbers between 1 to 255. 
// When the program is done, this array should have the values of [1, 3, 5, 7, ... 255].

var array = []

function arrayOddNumbers() {
    for (let i = 0; i < 256; i++) {
        if (i % 2 == 1) {
            array.push(i)
        }
    }
    return array
}

console.log(arrayOddNumbers());
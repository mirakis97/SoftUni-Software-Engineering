//function solve(text) {
    // let startIndex = 0;
    // let endIndex = 0;
    // let words = [];
    // for (let index = 0; index < text.length; index++) {
    //     const char = text[index];
    //     if ([',',';','?','!',':','~','"','\'', ' ','[',']'].includes(char)) {
    //         if (startIndex === endIndex) {
    //             continue;
    //         }
    //         let word = text.substring(startIndex,endIndex + 1);
    //         words.push(word.toUpperCase());
    //         startIndex = index + 1;
    //     }
    //     endIndex++;
    // }
    // if (startIndex <= endIndex) {
    //     let word = text.substring(startIndex,endIndex + 1);
    //     words.push(word.toUpperCase())
        
    // }
    // console.log(words);
    




    // console.log(text);
    // let words = text.split(/\W+|\?/g);
    // console.log(words);
//}
function wordUpperCase(input) {
    return input.toUpperCase().match(/\w+/gim).join(', ');
 }
wordUpperCase('Hi, how are you?');
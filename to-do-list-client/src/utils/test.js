function getAvailableNextWords(words, word) {
  const searchChar = word.charAt(word.length-1);
  return words.filter(tWord => searchChar === tWord.charAt(0))
}

function circuitWords(words) {
  return words.some(() => {
    const word = words.splice(0, 1)[0]; // 단어순회시 words에서 단어제거
    console.log(word);
    const nextAvailableWords = getAvailableNextWords(words, word); // 1.2 순회하는 단어의 끝글자
    console.log('다음에 올 수 있는 단어: ', nextAvailableWords);
    if (nextAvailableWords.length > 0) return circuitWords(words);
    return false;
  });
}

function solution(words) {
  let result = false;

  const tempWords = words;
  
  // 1. 단어순회
  circuitWords(tempWords);
  
  return result;
}

console.log(solution(["excavate", "endure", "desire", "screen", "theater", "excess", "night"]));
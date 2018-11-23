let arr = [1, 2, 3];

function map<T, U>(arr: T[], callback: (value: T) => U): U[] {
  let newArr: U[] = [];
  for (let index = 0; index < arr.length; index++) {
    const element = arr[index];
    newArr.push(callback(element));
  }
  return newArr;
}

export { map };

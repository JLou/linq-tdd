function map<TInput, TOuput>(array: TInput[], mapFn: (value: TInput) => TOuput): TOuput[] {
  let newArr: TOuput[] = [];

  for (let index = 0; index < array.length; index++) {
    const element = array[index];
    newArr.push(mapFn(element));
  }
  return newArr;
}

export { map };

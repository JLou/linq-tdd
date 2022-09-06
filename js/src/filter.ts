function filter<TInput>(array: TInput[], callbackFn: (value: TInput) => boolean): TInput[] {
  let newArray: TInput[] = [];
  for (let index = 0; index < array.length; index++) {
    const element = array[index];
    if(callbackFn(element)){
      newArray.push(element);
    }
  }
  return newArray;
}

export { filter };

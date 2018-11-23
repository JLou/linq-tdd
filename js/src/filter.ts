function filter<T>(array: T[], callbackFn: (T) => boolean): T[] {
  let newArray: T[] = [];
  for (let index = 0; index < array.length; index++) {
    const element = array[index];
    if (callbackFn(element)) {
      newArray.push(element);
    }
  }

  return newArray;
}

export { filter };

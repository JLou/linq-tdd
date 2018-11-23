function reduce<T, U>(
  array: T[],
  reducerFn: (acc: U, currentValue: T, currentIndex: number) => U,
  initialValue: U
): U {
  let acc: U = initialValue;
  for (let index = 0; index < array.length; index++) {
    const element = array[index];
    acc = reducerFn(acc, element, index + 1);
  }

  return acc;
}

export { reduce };

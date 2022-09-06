function every<T>(array: T[], predicate: (item: T) => boolean): boolean {
  for (let index = 0; index < array.length; index++) {
    const element = array[index];
    if (!predicate(element)) {
      return false;
    }
  }
  return true;
}

export { every };

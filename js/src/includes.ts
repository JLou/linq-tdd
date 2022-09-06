function includes(array: any[], searchElement: any): boolean {
  for (let index = 0; index < array.length; index++) {
    const element = array[index];

    if (
      element === searchElement ||
      (typeof element === "number" &&
        typeof searchElement === "number" &&
        isNaN(element) &&
        isNaN(searchElement))
    ) {
      return true;
    }
  }
  return false;
}

export { includes };

const basket = {
  status: {
    name: 'apple',
    count: 5,
  },
  getFruit() {
    this.status.count--;
    return this.status.count;
  },
};
const { getFruit, status: { count } } = basket;
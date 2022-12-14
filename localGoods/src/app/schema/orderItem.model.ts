export interface OrderItem{
  paymentMethodId: string,
  deliveryMethodId: string,
  deliveryInformation: string,
  orderDetails: {amount: number, productId: string}[]
}

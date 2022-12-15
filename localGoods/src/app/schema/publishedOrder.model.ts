import { OrderDetails } from "./orderDetails.model";

export interface PublishedOrderItem{
  id: string,
  createdAt: Date,
  userId: string,
  paymentMethodId: string,
  deliveryMethodId: string,
  deliveryInformation: string,
  orderStatusId: string,
  orderDetails: OrderDetails[]
}

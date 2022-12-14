import { DeliveryMethod } from "./deliveryMethod.model"
import { Good } from "./good.model"
import { PaymentMethod } from "./paymentMethod.model"

export interface Vendor{
  id:string,
  name:string,
  viberNumber:string,
  telegramName:string,
  instagramName:string,
  userId:string,
  products: Good[],
  paymentMethods: PaymentMethod[],
  deliveryMethods: DeliveryMethod[]
}


export interface VendorRegister{
  name: string,
  viberNumber: string,
  telegramName: string,
  instagramName: string,
  paymentMethods: {paymentMethodId:string}[],
  deliveryMethods:{ deliveryMethodId: string, information: string}[]
}


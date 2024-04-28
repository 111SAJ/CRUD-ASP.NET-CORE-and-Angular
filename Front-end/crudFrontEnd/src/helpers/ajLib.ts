import { env } from "./env";
declare var cuteToast: any

export const ajLib = {
    notification: {
        toast: function (type: string, message: string) {
            return cuteToast({
                title: 'Message',
                type: type,
                message: message
            })
        }
    },
    store: function (o: Object): void {
        try {
          localStorage.setItem('ls_u_data', JSON.stringify(o))
        } catch (e) {
          ;
        }
      },
      get: function (key: string | null = null) {
        try {
          return JSON.parse(localStorage.getItem('ls_u_data') + '')
        } catch (e) {
          return null
        }
      },
      clear: function () {
        try {
          localStorage.removeItem('ls_u_data')
        } catch (e) {
          ;
        }
      },
}
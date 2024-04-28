import { env } from "./env";

export const endpoints = {
    employee:{
        index:env.endpoints.base+"Employee/index",
        create:env.endpoints.base+"Employee/create"
    }
}
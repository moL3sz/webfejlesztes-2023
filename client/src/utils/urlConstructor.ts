import {UrlParamsType} from "./@types/urlParams.type.ts";
import {API_URL} from "../config/globals.ts";


export const url = ({controller, action, parameter}: UrlParamsType): string=>{
	return  `${API_URL}/${controller}${action ? "/" + action : ""}${parameter ? "/" + parameter : ""}`
}
import {DicUrlType, UrlParamsType} from "./@types/urlParams.type.ts";
import {API_URL} from "../config/globals.ts";


export const url = ({controller, action, parameter}: UrlParamsType): string=>{
	return  `${API_URL}/${controller}${action ? "/" + action : ""}${parameter ? "/" + parameter : ""}`
}
export const dicUrl = ({dictionaryName, action,projectId}: DicUrlType): string=>{
	return  `${API_URL}/DictionaryManager/${dictionaryName}${action ? "/" + action : ""}${projectId ? "/" + projectId : ""}`
}
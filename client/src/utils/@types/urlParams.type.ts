import {Actions} from "../../config/api/actions.enum.ts";


export type UrlParamsType = {
	controller: string
	action: Actions | string
	parameter?: string
}
export type DicUrlType = {
	dictionaryName: string,
	action: Actions | string
	projectId: number | string | undefined
}
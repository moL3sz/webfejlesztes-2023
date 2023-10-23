
import CustomStore from "devextreme/data/custom_store";
import {LoadOptions} from "devextreme/data/load_options";
import {getApi} from "../config/api/api.ts";


type StoreOptions  =  {
	key: string,
	loadUrl?: string,
	insertUrl?: string,
	updateUrl?: string,
	deleteUrl?: string,
	withCredentials?: boolean,
	withCredentialsOnGet?: boolean,
	getByIdUrl?: string
}


/**
 * <p>CRUD Művletek Aktívak!</p>
 *  <strong style="color: red">FONTOS NEM MINDEN paraméter van használva a storeban, 2023.06.28</strong>
 *
 *
 *
 * @param options Ezekkel a paraméterekkel lehet configolni a kéréseket, kibővített verziója a ASPNet.createStore optionnek!
 */
export const datagridStore = <T, >(options: StoreOptions) => {


	const load = async (loadOptions: LoadOptions): Promise<any> => {
			const response = await getApi().get<T>(options.loadUrl || "", {
			withCredentials: options.withCredentialsOnGet || options.withCredentials,
		})
		return new Promise((resolve, reject) => {
			// Ha hibát dob vissza az API
			if (response.status >= 300) {
				reject()
			} else {
				resolve(response.data)
			}
		});
	}

	const byKey = async (key: string):Promise<T>=>{
		const response = await getApi().get<T>(options.getByIdUrl + `/${key}` || "", {
			withCredentials: options.withCredentialsOnGet || options.withCredentials,
			headers: {
			}
		})
		return new Promise((resolve, reject) => {
			// Ha hibát dob vissza az API
			if (response.status >= 300) {
				reject()
			} else {
				resolve(response.data)
			}
		});
	}
	const insert = (values: T) => {
		if (options.insertUrl === undefined) {
			return new Promise(() => {
			})
		}
		//Nem kell nekünk ez a kulcs
		delete (values as any)["__KEY__"];
		return getApi().post<T>(options.insertUrl!, values, {
			withCredentials: options.withCredentials,


		}) as PromiseLike<any>
	}

	const update = (key: string, values: T) => {
		if (options.insertUrl === undefined) {
			return new Promise(() => {
			})
		}
		delete (values as any)["__KEY__"];
		return getApi().put<T>(options.updateUrl!, values, {
			withCredentials: options.withCredentials,
		}) as PromiseLike<any>

	}
	const remove = (key: string) => {
		if (options.deleteUrl === undefined) {
			return new Promise(() => {
			})
		}
		return getApi().delete(`${options.deleteUrl}/${key}`, {
			withCredentials: options.withCredentials,

		}) as PromiseLike<any>
	}


	return new CustomStore({
		load,
		byKey,
		insert,
		update,
		remove,
		key: options.key || "Id",
		loadMode: "processed",
	})
}


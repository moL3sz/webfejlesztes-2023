import {useEffect, useState} from "react";
import {getApi} from "../../config/api/api.ts";
import {dicUrl} from "../../utils/urlConstructor.ts";
import {useParams} from "react-router-dom";
import {Actions} from "../../config/api/actions.enum.ts";


export const useDataSource = <T extends readonly string[], >(dictionaries: T): Record<T[number], object> => {

	const defaultState = {}
	dictionaries.forEach((item) => {
		(defaultState as any)[item] = []
	})
	const {id} = useParams<{ id: string }>()
	const [dataSources, setDataSources] = useState<any>(defaultState)

	useEffect(() => {
		const promises: any[] = []

		dictionaries.forEach((dictionaryName) => {
			promises.push(new Promise((resolve) => {
				getApi().get(dicUrl({dictionaryName, action: Actions.GET_ALL_BY_PROJECT, projectId: id}))
					.then((response) => {
						setDataSources((prev: any) => ({...prev, [dictionaryName]: response?.data || []}))
						resolve(true)
					})
			}));
		})
		Promise.all(promises).then(() => {
		})


	}, [])


	return dataSources;


}
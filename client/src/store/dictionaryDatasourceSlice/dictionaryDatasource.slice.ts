import {createSlice, PayloadAction} from "@reduxjs/toolkit";

type DictionaryDatasourceState = {
	dataSources:any
};


const initialState : DictionaryDatasourceState = {
	dataSources: {}
};


const dictionaryDatasourceSlice = createSlice({
	name:"drawer",
	initialState,
	reducers:{
		setDictionaryDataSources(state,{payload}: PayloadAction<DictionaryDatasourceState>){
			state.dataSources = {...state.dataSources,...payload.dataSources};
		}
	}
});




export const { setDictionaryDataSources} = dictionaryDatasourceSlice.actions;
export const dictionaryDatasourceReducer = dictionaryDatasourceSlice.reducer;

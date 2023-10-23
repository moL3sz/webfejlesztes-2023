import {createSlice, PayloadAction} from "@reduxjs/toolkit";

type CurrentProjectState = {
	currentProjectId: number |  null | string
};


const initialState : CurrentProjectState = {
	currentProjectId: null
};


const currentProjectSlice = createSlice({
	name:"currentProject",
	initialState,
	reducers:{
		setCurrentProjectId(state, {payload}:PayloadAction<string | null | number>){
			state.currentProjectId = payload
		}
	}
});




export const { setCurrentProjectId } = currentProjectSlice.actions;
export const currentProjectReducer = currentProjectSlice.reducer;

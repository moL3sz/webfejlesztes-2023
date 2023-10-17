import {createSlice} from "@reduxjs/toolkit";

type DrawerState = {
	opened:boolean
};


const initialState : DrawerState = {
	opened:false
};


const drawerSlice = createSlice({
	name:"drawer",
	initialState,
	reducers:{
		toggleDrawer(state){
			state.opened = !state.opened;
		},
		openDrawer(state){
			state.opened = true;

		},
		closeDrawer(state){
			state.opened = false;

		}
	}
});




export const { toggleDrawer, openDrawer,closeDrawer } = drawerSlice.actions;
export const drawerReducer = drawerSlice.reducer;

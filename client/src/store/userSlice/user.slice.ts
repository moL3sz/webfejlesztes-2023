import {createSlice, PayloadAction} from "@reduxjs/toolkit";
import {UserType} from "../@types/user.type.ts";

type UserState = {
	user:UserType
};


const initialState : UserState = {

};


const userSlice = createSlice({
	name:"drawer",
	initialState,
	reducers:{
		setUserData(state, {payload}:PayloadAction<UserType>){
			state.user = payload;
		}
	}
});




export const { setUserData } = userSlice.actions;
export const userReducer = userSlice.reducer;

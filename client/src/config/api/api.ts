import axios from "axios";


const axiosInstance = axios.create({
	headers: {
		"Content-Type": "application/json"
	},
	withCredentials: true,
	decompress: true
})



export const getApi = ()=>axiosInstance;
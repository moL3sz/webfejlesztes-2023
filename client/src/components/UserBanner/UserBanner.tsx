import {memo, useState} from "react";


export const UserBanner = memo(({FullName, idx}: { FullName: string, idx?: number }) => {
	const [n1, n2] = FullName.split(" ");
	const id = "member_" + idx
	const short = n1[0].toUpperCase() + n2[0].toUpperCase();
	const [viewState, setViewState] = useState(short);
	return (
		<div
			className={"user-banner bg-sky-800 hover:w-max hover:rounded-[5em] hover:mx-4 hover:font-normal hover:px-2 border-[1px]"}
			id={id} onMouseEnter={() => {
			setViewState(FullName)
		}} onMouseLeave={() => {
			setViewState(short)
		}} style={{
			transform: `translateX(${10 + -(idx || 0) * 5}px)`
		}}>
			<span>
				{viewState}
			</span>

		</div>
	)
})
<script>
import axios from 'axios'

export default{
	methods: {
		getPosts1(){
			axios.get('http://localhost:5089/breakfasts/00000000000000000000000000000001')
			.then(response => {
				console.log(response.data)
			})
			.catch(error => {
				console.log(error)
			})
		},
		getPosts2(){
			axios.get('http://localhost:5089/breakfasts/00000000000000000000000000000002')
			.then(response => {
				console.log(response.data)
			})
			.catch(error => {
				console.log(error)
			})
		},
		getPosts3(){
			axios.get('http://localhost:5089/breakfasts/00000000000000000000000000000003')
			.then(response => {
				console.log(response.data)
			})
			.catch(error => {
				console.log(error)
			})
		},
		getPosts4(){
			axios.get('http://localhost:5089/breakfasts/00000000000000000000000000000004')
			.then(response => {
				console.log(response.data)
			})
			.catch(error => {
				console.log(error)
			})
		},
	}
}
</script>

<template>
	<button @click="getPosts1">Get Posts</button>
	<button @click="getPosts2">Get Posts</button>
	<button @click="getPosts3">Get Posts</button>
	<button @click="getPosts4">Get Posts</button>
</template>


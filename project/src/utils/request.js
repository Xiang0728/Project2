import axios from 'axios';


export let apiPostMail = (Mail,Name,Msg) => axios.post('/API/SendMail/Send',{Mail,Name,Msg});

export let apiGetAll = () => axios.get('/API/GetMail/All');
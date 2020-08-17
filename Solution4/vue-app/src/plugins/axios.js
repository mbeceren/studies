import axios from 'axios'
import MockAdapter from 'axios-mock-adapter'
const DEBUG = process.env.NODE_ENV === "development";
var created = axios.create({
    baseURL: "http://localhols:80808/api",
});

created.interceptors.request.use((config) => {
    if (DEBUG){
        console.log(config);
    }       
        return Promise.resolve(config);
  });

  created.interceptors.response.use((response) => {
    if (DEBUG){
        console.log(response);
    }       
        return Promise.resolve(response);
  });

  if (DEBUG){
    const mock = new MockAdapter(created);

    mock.onPost("/login").reply(200, {
      token: "123456789",
      user: "admin"
    });
    
    localStorage.removeItem("appointments");
    var appointments = [{
      id: 1,
      title: "Appointment 1",
      date: "2020-08-21",
      location: "Location 1"
    },{
     id: 2,
     title: "Appointment 2",
     date: "2020-08-23",
     location: "Location 2"
   }];
   localStorage.setItem("appointments", JSON.stringify(appointments));
    mock.onGet("/appointments").reply(function(){
        return [200, { appointments: localStorage.getItem("appointments") }];
    });

    mock.onPost("/appointment-add").reply(function(config){
      console.log("here");
      console.log(config);
        if (config.data != null && config.data != ''){
          var strApps = localStorage.getItem("appointments");
          if (strApps != ''){
            var appointments = JSON.parse(strApps);
            var appointment = JSON.parse(config.data);
            var last = appointments.filter(function(e1, e2){
              return e1 > e2 ? e1 : e2;
            });
            appointment.id = last[0].id + 1;
            console.log(appointment);
            appointments.push(appointment);
            localStorage.setItem("appointments", JSON.stringify(appointments));
          }
        }
        return [200, {}];
    })

  }

export default created;
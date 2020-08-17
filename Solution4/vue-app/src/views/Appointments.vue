<template>
    <div class="appointments">
        <h1>Appointments</h1>
        <hr>
        <b-table striped hover :items="appointments"></b-table>
    </div>
</template>

<script>
export default {
    name: "Appointments",
    data() {
        return{
            appointments: null
        }
    },
    mounted(){
        this.$store.dispatch("getAppointments").then(response =>  {
            this.appointments = JSON.parse(response.data.appointments);
        })
    }
}
</script>
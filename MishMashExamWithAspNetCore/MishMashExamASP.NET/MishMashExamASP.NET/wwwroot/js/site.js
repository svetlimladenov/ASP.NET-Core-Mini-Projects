// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.

$(document).ready(() => {
    const followedChannels = $('#followed-channels');
    const otherChannels = $('#other-channels');
    document.querySelectorAll('.follow-channel').forEach(ch => {
        ch.addEventListener('click',
            () => {
                let channelId = ch.dataset.channelId;
                $.post('Channels/FollowChannel', { channelId })
                    .then((data) => {
                        let box = $(ch.parentElement.parentElement);
                        let followersCount = Number($(ch.parentElement).prev().prev().text().split(' ')[1]) + 1;
                        $(ch.parentElement).prev().prev().text(`Followers ${followersCount}`);
                        $(ch.parentElement).remove();
                        box.append('<h5>Following</h5>');
                        followedChannels.append(box);
                    })
                    .catch(() => { console.log('error') });
            });
    });


    document.querySelectorAll(".unfollow").forEach(ch => {
        ch.addEventListener('click',
            () => {
                let channelId = ch.dataset.channelId;
                $.post('/Channels/UnfollowChannel', { channelId })
                    .then((data) => {
                        let row = $(ch.parentElement.parentElement.parentElement);
                        row.remove();
                    });
            });
    });
})